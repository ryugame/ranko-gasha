using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour {
    //HP
    public int hp;

    //Characterコンポーネント
    Character character;

    IEnumerator Wait() {
        yield return new WaitForSeconds(wait);
        float x = Mathf.Cos(Time.time + wait * speed) * width;
        float y = Mathf.Sin(Time.time + wait * speed) * height;
        float z = 0f;

        transform.position = new Vector3(x, y, z);

        Vector3 pos = transform.position;
        pos.x += 4.0f;
        transform.position = pos;
    }
    public float speed = 4f;
    public float width = 2f;
    public float height = 2f;
    public float wait;




     IEnumerator Start() {


        //Characterコンポーネントを取得
        character = GetComponent<Character>();

        while (true) {
            //子要素をすべて取得する
            for (int i = 0; i < transform.childCount; i++) {
                Transform shotPosition = transform.GetChild(i);

                //ShotPositionの位置/角度で弾を撃つ
                character.Shot(shotPosition);
            }

            //shotDelay秒待つ
            character.shotDelay = Random.Range(0.5f, 2);

            yield return new WaitForSeconds(character.shotDelay);
        }
    }
    void Update() {
        StartCoroutine("Wait");
    }
    void OnTriggerEnter2D(Collider2D c)
    {

        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet (Player)以外の時は何も行わない
        if (layerName != "Bullet (Player)")
            return;

         //PlayerBulletのTransformを取得
        Transform PlayerBulletTransform = c.transform.parent;

         //Bulletコンポーネントを取得
        //Bullet Bullet = PlayerBulletTransform.GetComponent<Bullet>();


        // ヒットポイントを減らす
        hp = hp - 1;

        // 弾の削除
        Destroy(c.gameObject);

        // ヒットポイントが0以下であれば
        if (hp <= 0)
        {
            // エネミーの削除
            //Destroy (gameObject);
        }
    }
}
