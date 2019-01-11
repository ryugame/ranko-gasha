using UnityEngine;
using System.Collections;

public class 蘭子 : MonoBehaviour
{
    // Spaceshipコンポーネント
    Character character;

    public int scoreValue;
    public int scoreValuesp;
    private ScoreManager sm;

    public void Start(){
        // Spaceshipコンポーネントを取
        character = GetComponent<Character>();
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();


        StartCoroutine("Shot");

    }
    IEnumerator Shot()
    {
        while (true)
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            character.Shot(transform);

            // ショット音を鳴らす
            //GetComponent<AudioSource>().Play();

             //shotDelay秒待つ
            yield return new WaitForSeconds(character.shotDelay);
        }
    }

    void Update()
    {
        // 右・左
        float x = Input.GetAxisRaw("Horizontal");

        // 上・下
        float y = Input.GetAxisRaw("Vertical");

        // 移動する向きを求める
        Vector2 direction = new Vector2(x, y).normalized;

        // 移動の制限
        Move(direction);

    }

    // 機体の移動
    void Move(Vector2 direction)
    {
        // 画面左下のワールド座標をビューポートから取得
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // 画面右上のワールド座標をビューポートから取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // プレイヤーの座標を取得
        Vector2 pos = transform.position;

        if(Input.GetKey(KeyCode.LeftShift)) {
            character.speed = 3;
            pos += direction * character.speed * Time.deltaTime;
        } else {
            character.speed = 8;
            pos += direction * character.speed * Time.deltaTime;
        }

        // プレイヤーの位置が画面内に収まるように制限をかける
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // 制限をかけた値をプレイヤーの位置とする
        transform.position = pos;
    }

    // ぶつかった瞬間に呼び出される
    void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet (Enemy)の時は弾を削除
        if (layerName == "Bullet (Enemy)")
        {
            // 弾の削除
            Destroy(c.gameObject);
            sm.AddScoresp(scoreValuesp);

            //string yourTag = gameObject.tag;
            if(c.tag == "Bullet2") {
                sm.AddScore(Random.Range(15, 51));
            } else if (c.tag == "Bullet1") {
                sm.AddScore(scoreValue);
            }
        }

        // レイヤー名がBullet (Enemy)またはEnemyの場合は爆発
        if (layerName == "Bullet (Enemy)" || layerName == "Enemy")
        {
            //// Managerコンポーネントをシーン内から探して取得し、GameOverメソッドを呼び出す
            //FindObjectOfType<Manager>().GameOver();

            // プレイヤーを削除
            //Destroy(gameObject);
        }
    }
}