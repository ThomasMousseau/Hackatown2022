import React from 'react';
import { Article } from '../models/article.model';
import styles from '../styles/Article.module.css';

const ArticleCpt = (props: any) => {
    const article: Article = props.article;
    return (
        <div className={styles.article}>
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