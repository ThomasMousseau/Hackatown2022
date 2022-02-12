export interface Article {
    publicationDate: Date;
    publication: string;
    authorName: string;
    authorTwitter: string;
    title: string;
    thumbnail: string;
    l2r: number; //faudrait le changer pour qu'il soit un float
    link: string;
}