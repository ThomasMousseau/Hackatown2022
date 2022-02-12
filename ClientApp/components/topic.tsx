import React from 'react';
import { Article } from '../models/article.model';
import { Topic } from '../models/topic.model';
import ArticleCpt from './article';
import styles from '../styles/Topic.module.css';

const TopicCpt = (props: Topic) => {
    return (
        <div className={styles.topic}>
            <h2>{props.importance}. {props.title}</h2>
            <div className={styles.articles}>
                <div className={styles.overlay}></div>
                {
                    props.articles.map((a: Article, i: number) => {
                        return (<ArticleCpt key={i} article={a}/>);
                    })
                }
            </div>
        </div>
    );
};

export default TopicCpt;