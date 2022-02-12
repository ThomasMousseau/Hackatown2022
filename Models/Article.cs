using System;

namespace Models {
    public class Article
    {
        public DateTime publicationDate;
        public string publication, authorName, authorTwitter, title, thumbnail, link; 
        public int l2r;
    }
}
/*export interface Article {
    publicationDate: Date;
    publication: string;
    authorName: string;
    authorTwitter: string;
    title: string;
    thumbnail: string;
    l2r: number;
    link: string;
} */