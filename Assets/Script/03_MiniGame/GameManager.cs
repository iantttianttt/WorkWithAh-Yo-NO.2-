using UnityEngine;
using System.Collections;

namespace MiniGame{

	public class GameManager : MonoBehaviour {


		#region make GameManager Global
		public static GameManager _gameManager;
		public static GameManager Main {
			get {
				if (_gameManager == null) {
					_gameManager = GameObject.Find("GameManager").GetComponent<GameManager> ();
				}
				return _gameManager;
			}
		}

		private GameManager () {}
		#endregion


		public enum GamingStage {
			Instruction,
			ReadyToStart,
			Playing,
			End
		}


		public GamingStage gamingStage ;
		public int score;
		public int level = 60;
		public float gamingTime;
		public int levelCounter;

		private MonsterCreator_BossMotion monsterCreator;


		void Awake () {
			monsterCreator = GameObject.Find ("Boss").GetComponent<MonsterCreator_BossMotion> ();
		}

		void Start () {
			gamingStage = GamingStage.Instruction;
		}
		

		void Update () {
			levelCalculate ();
		}



		#region Private Function

		private void levelCalculate () {
			if (levelCounter > 5) {
				level++;
				levelCounter = 1;
			}
		}

		private IEnumerator PlayingTimer () {
			yield return new WaitForSeconds (gamingTime);
			gamingStage = GamingStage.End;
		}

		#endregion


		#region public Function

		public void GameStart () {
			gamingStage = GamingStage.Playing;
			StartCoroutine (PlayingTimer ());
			monsterCreator.StartMonsterCreateSystem ();
		}

		#endregion
	}
}
