using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class GameController : MonoBehaviour
{
		public const int NUMBER_OF_LEVELS = 1;
		private static Stopwatch gameWatch;

		public static bool[] UnlockedLevels {
				get;
				private set;
		}

		//private static GameController activeInstance;
		public static int TotalScore {
				get {
						int r_score = 0;
						foreach (int i in levelScores) {
								r_score += i;
						}
						return r_score;
				}
		}

		private static int[] levelScores {
				get;
				set;
		}

		private static int currentLevelScore;
		private static int currentLevelIndex;

		void Awake ()
		{
				//activeInstance = this;
		}

		void Start ()
		{
				levelScores = new int[NUMBER_OF_LEVELS];
				UnlockedLevels = new bool[NUMBER_OF_LEVELS];

				gameWatch = new Stopwatch ();

				//Load progress
				for (int i=0; i<NUMBER_OF_LEVELS; i++) {
						levelScores [i] = PlayerPrefs.GetInt ("LevelScore_" + i.ToString (), 0);
						UnlockedLevels [i] = PlayerPrefs.HasKey ("LevelUnlocked_" + i.ToString ());
				}
		}

		public static GameObject SpawnEnemy (GameObject a_enemy, Vector3 a_position)
		{
				return (GameObject)GameObject.Instantiate (a_enemy, a_position, Quaternion.identity);
		}
	
		public static void SpawnDeathLinkedEnemy (GameObject a_enemy, Vector3 a_position, ITriggableByDeath a_toTrigger)
		{
				a_enemy = (GameObject)GameObject.Instantiate (a_enemy, a_position, Quaternion.identity);
				EnemyHealth t_enemyHealth = a_enemy.GetComponent<EnemyHealth> ();

				if (t_enemyHealth != null)
						a_toTrigger.Subscribe (t_enemyHealth);
		}

		public static void StartLevel (int a_levelIndex)
		{
				currentLevelScore = 0;
				currentLevelIndex = a_levelIndex;
				gameWatch.Reset ();
				gameWatch.Start ();
		}

		public static void EndLevel ()
		{
				gameWatch.Stop ();

				print ("You beat the level in " + gameWatch.ElapsedMilliseconds.ToString () + " milliseconds!");

				//Unlock the next level
				if (currentLevelIndex + 1 < NUMBER_OF_LEVELS) {
						UnlockedLevels [currentLevelIndex + 1] = true;
						PlayerPrefs.SetInt ("LevelUnlocked_" + (currentLevelIndex + 1).ToString (), 0);
				}

				//Update high score if appropriate
				if (currentLevelScore > levelScores [currentLevelIndex]) {
						levelScores [currentLevelIndex] = currentLevelScore;
						PlayerPrefs.SetInt ("LevelScore_" + currentLevelIndex.ToString (), currentLevelScore);
						print ("New highscore!");
				}					
		}

		public static void LoseGame ()
		{
				print ("You died");
		}
}
