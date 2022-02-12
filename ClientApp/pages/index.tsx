import type { NextPage } from 'next'
import Head from 'next/head'
import styles from '../styles/Home.module.css'
import { TopicService } from '../services/topic.service'
import React from 'react';
import { Topic } from '../models/topic.model';
import TopicCpt from '../components/topic';

const topicService = new TopicService();

const Home: NextPage = () => {
  const [topics, setTopics] = React.useState<Topic[]>([]);
  
  topicService.getTopics().then(res => {
    setTopics(res.data);
  });


  return (
    <div className={styles.container}>
      <Head>
        <title>Your News Today</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <main className={styles.main}>
        <h1 className={styles.title}>
          Your News Today: {new Date().toLocaleDateString()}
        </h1>

        <div className={styles.topics}>
          {
            topics.map((t: Topic) => {
              <TopicCpt key={t.importance} title={t.title} importance={t.importance} artciles={t.artciles}  />
            })
          }
        </div>
      </main>
    </div>
  )
}

export default Home
