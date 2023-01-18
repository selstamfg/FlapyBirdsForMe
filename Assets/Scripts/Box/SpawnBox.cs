using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
	private static int spawnChanceBox0;
	private static int spawnChanceBox1;
	private static int spawnChanceBox3;
	private static int spawnChanceBox5;
	private static int spawnChanceBox7;

	int missCount;

	private static int ChanceBox0 = 100-spawnChanceBox0;
	private static int ChanceBox1 = ChanceBox0- spawnChanceBox1;
	private static int ChanceBox3 = ChanceBox1 -  spawnChanceBox3;
	private static int ChanceBox5 = ChanceBox3 - spawnChanceBox5;
	private static int ChanceBox7 = ChanceBox5 - spawnChanceBox7;

	[SerializeField] private Box[] _enemyTemplates;
	private void SpawnBoxfirst()
    {

		int spawnChanceBox = Random.Range(0, 100);
		
			for(int i = 0;i<_enemyTemplates.Length; i++)
            {
				Vector2Int chances = _enemyTemplates[i].GetChances;

				if(spawnChanceBox>=chances.x && spawnChanceBox<=chances.y)
                {
				
					break;
                }
            }
	}
   
}
