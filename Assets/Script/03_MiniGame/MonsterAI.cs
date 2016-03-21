using UnityEngine;
using System.Collections;

namespace MiniGame{

	public class MonsterAI : MonoBehaviour {

		public enum MonsterType
		{
			FatGuy,
			Assassin,
			FourLeg
		}


		public MonsterType monsterType;

		void Awake () {

		}

		void Start () {

		}


		void Update () {
			MonsterMotion ();
		}


		private void MonsterMotion () {
			switch (monsterType) {
			case MonsterType.FatGuy:

				break;
			case MonsterType.Assassin:

				break;
			case MonsterType.FourLeg:

				break;
			}
		}

		public void GetKill () {
			switch (monsterType) {
			case MonsterType.FatGuy:
				GameManager.Main.score++;
				GameManager.Main.levelCounter++;
				break;

			case MonsterType.Assassin:
				GameManager.Main.score++;
				GameManager.Main.levelCounter++;
				break;

			case MonsterType.FourLeg:
				GameManager.Main.score += 3;
				GameManager.Main.levelCounter++;
				break;
			}
		}

		private void Die (){

		}
	}
}
