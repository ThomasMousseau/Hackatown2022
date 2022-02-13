import type { NextApiRequest, NextApiResponse } from 'next';
import { TextAnalyticsClient, AzureKeyCredential } from '@azure/ai-text-analytics';

const key = "1dde6efad47f443485ec69b357bb68c3";
const endpoint = "https://hackatown2022.cognitiveservices.azure.com/";

export default async function handler(
    req: NextApiRequest,
    res: NextApiResponse<string>
) {
    const client = new TextAnalyticsClient(endpoint, new AzureKeyCredential(key));
    let text = req.body.content;
    console.log(text);
    summarize(text, client).then(
        (result) => {
            console.log(result);
            res.json(result);
        }
    );
}


async function summarize(content: string, client: TextAnalyticsClient): Promise<string> {
    const documents = [content];

    const actions = {
        extractSummaryActions: [{ modelVersion: "latest", orderBy: "Rank", maxSentenceCount: 5 }],
    };
    const poller = await client.beginAnalyzeActions(documents, actions, "en");

    poller.onProgress(() => {
        console.log(
            `Number of actions still in progress: ${poller.getOperationState().actionsInProgressCount}`
        );
    });

    const resultPages = await poller.pollUntilDone();

    let result = "";

    for await (const page of resultPages) {
        const extractSummaryAction = page.extractSummaryResults[0];
        if (!extractSummaryAction.error) {
            for (const doc of extractSummaryAction.results) {
                if (!doc.error) {
                    for (const sentence of doc.sentences) {
                        result += sentence.text + " ";
                    }
                } else {
                    console.error("\tError:", doc.error);
                }
            }
        }
    } 

    return result;
}