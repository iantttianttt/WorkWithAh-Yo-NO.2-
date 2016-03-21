using UnityEngine;
using System.Collections;


namespace MiniGame{
	
	public class MonsterCreator_BossMotion : MonoBehaviour {

		public GameObject[] monsterType = new GameObject[3];
		public Transform[] spwonPoint = new Transform[5];
		private int fatGuyPercentage = 50;
		private int assassinPercentage = 30;
		private float monsterCreateCD = 4f;
		private bool isMoving = false;
		private Transform pointToGo;

		void Awake () {

		}

		void Start () {

		}


		void Update () {
			monsterCreateCD = 4f - (GameManager.Main.level*0.3f);

			if(isMoving == true){
				this.transform.position = Vector3.Lerp (this.transform.position, pointToGo.position, 1);
			}

		}


		void LateUpdate () {
			if (isMoving == true) {
				if (Mathf.Abs (this.transform.position.x - pointToGo.position.x) < 0.5f) {
					isMoving = false;
				}
			}
		}


		private Transform SpwonPointCalculate () {
			return spwonPoint [Random.Range (0, 4)];
		}

		private GameObject SpwonMonsterCalculate () {
			int randomNum = Random.Range (1, 100);
			if (randomNum <= fatGuyPercentage) {
				return monsterType [0];
			} else if (randomNum > fatGuyPercentage && randomNum <= fatGuyPercentage + assassinPercentage) {
				return monsterType [1];
			} else {
				return monsterType [2];
			}
		}
			
		private IEnumerator MonsterCreateTimer () {
			if (GameManager.Main.gamingStage != GameManager.GamingStage.Playing) {
				yield break;
			}
			yield return new WaitForSeconds (monsterCreateCD);
			CreateNewMonster (SpwonPointCalculate (), SpwonMonsterCalculate ());
		}

		private IEnumerator GoToSpwonPoint (Transform _spwonPoint) {
			pointToGo = _spwonPoint;
			isMoving = true;
			while (isMoving == true) {
				yield return null;
			}
		}

		private void CreateNewMonster (Transform _spwonPoint, GameObject _monsterType) {
			if(_monsterType != monsterType[2]){
				StartCoroutine(GoToSpwonPoint(_spwonPoint));
			}
			ObjectPool.Spawn (_monsterType, _spwonPoint.position, _spwonPoint.rotation);
			StartCoroutine (MonsterCreateTimer ());
		}





		public void StartMonsterCreateSystem () {
			CreateNewMonster(SpwonPointCalculate(),SpwonMonsterCalculate());
		}

	}
}

