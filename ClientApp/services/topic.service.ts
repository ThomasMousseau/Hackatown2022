import { Topic } from "../models/topic.model";
import https from "https";

export class TopicService {
  apiUrl = "https://localhost:7219"
  agent = new https.Agent({
    rejectUnauthorized: false
  })

  getTopics(): Promise<Response> {
    console.log("in GetTopics()");
    return fetch(`${this.apiUrl}/api/main/topics`, { agent: this.agent } as RequestInit);
  }
}