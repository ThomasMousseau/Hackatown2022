namespace Models {
    public class Topic
    {
        public int importance;
        public string title;
        public Article[] articles;
    }
}

/*import { Article } from "./article.model";
export interface Topic {
    title: string;
    importance: number;
    artciles: Article[];
} */