import React from 'react';
import { Article } from '../models/article.model';
import { Topic } from '../models/topic.model';
import ArticleCpt from './article';
import styles from '../styles/Topics.module.css';

const TopicCpt = (props: Topic) => {
    console.log("in [TopicCpt]");

    return (
        <div>
            <h2>{props.importance}. {props.title}</h2>
            {/* <div>
                {
                    props.artciles.map((a: Article) => {
                        return <ArticleCpt article={a}/>
                    })
                }
            </div> */}
        </div>
    );
};

export default TopicCpt;