import { Article } from "./article.model";

export interface Topic {
    title: string;
    importance: number;
    artciles: Article[];
}