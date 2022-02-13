
import React, { useEffect } from 'react';
import { Article } from '../models/article.model';
import styles from '../styles/Article.module.css';
import https from "https";
import { TextAnalyticsClient, AzureKeyCredential } from '@azure/ai-text-analytics';

const key = "1dde6efad47f443485ec69b357bb68c3";
const endpoint = "https://hackatown2022.cognitiveservices.azure.com/";

const ArticleCpt = (props: any) => {
    const article: Article = props.article;
    const client = new TextAnalyticsClient(endpoint, new AzureKeyCredential(key));

    const [summary, setSummary] = React.useState<string | null>(null);
    const [isLoading, setLoading] = React.useState(false)
    const agent = new https.Agent({
      rejectUnauthorized: false
    })

    const loadSummary = async () => {
        const documents = [article.content];
    
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
    
        setSummary(result);
    }

    return (
        <div className={styles.article} onMouseEnter={loadSummary}>
            <p className={styles.hoverState}>
                {
                    summary ?? "Loading...."
                }
            </p>
            <div className={styles.header}>
                <span className={styles.date}>{new Date(article.publicationDate).toLocaleDateString()}</span>
                <span className={styles.publication}>{article.publication}</span>
            </div>

            <img src={article.thumbnail} className={styles.thumbnail}></img>

            <div className={styles.toast}>
                <a className={styles.title} href={article.link} target="_blank">{article.title}</a> 
                <br />
                <a className={styles.author} href={article.authorTwitter} target="_blank">{article.authorName}</a>
            </div>
        </div>
    );
};

export default ArticleCpt;