import type { NextPage } from 'next'
import Head from 'next/head'
import styles from '../styles/Home.module.css'

const Home: NextPage = () => {
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

        </div>
      </main>
    </div>
  )
}

export default Home
