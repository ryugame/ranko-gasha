using UnityEngine;
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class Character : MonoBehaviour
    {
    private ScoreManager sm;
        // 移動スピード
        public float speed;

        private ちひろさん tihi;

        // 弾を撃つ間隔
        public float shotDelay;

        // 弾のPrefab
        public GameObject Bullet1;
        public GameObject Bullet2;

        // 弾を撃つかどうか
        public bool canShot;

        // アニメーターコンポーネント
        private Animator animator;

    public int GetChance;

        void Start()
        {
        tihi = GameObject.Find("ちひろさん").GetComponent<ちひろさん>();
            // アニメーターコンポーネントを取得
            animator = GetComponent<Animator>();
        }
        // 弾の作成
        public void Shot(Transform origin){
        if(GetChance <= Random.Range(0, 100)) {
            Instantiate(Bullet1, origin.position, origin.rotation);
        } else {
            Instantiate(Bullet2, origin.position, origin.rotation);
                
        }
        }
     void Update() {
        GetChance = tihi.GetChance;   
    }
    // アニメーターコンポーネントの取得
    public Animator GetAnimator(){
            return animator;
        }
    }
