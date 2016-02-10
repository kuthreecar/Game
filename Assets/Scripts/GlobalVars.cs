using UnityEngine;
using System.Collections;

public class GlobalVars : MonoBehaviour {

	public static int point = 0;

	public enum Team{
		Batu,
		Xingxin,
		Lanyu,
		Weicao,
		Lunhui
	}
	public static Team team = Team.Batu;

	public static bool canBigAct = false;

}
