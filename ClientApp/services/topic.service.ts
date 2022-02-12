import { Topic } from "../models/topic.model";
import axios, { AxiosResponse } from "axios";

export class TopicService {
  getTopics(): Promise<AxiosResponse<Topic[]>> {
    return axios.get("/api/topics");
  }
}