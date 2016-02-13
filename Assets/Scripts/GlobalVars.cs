using UnityEngine;
using System.Collections;

public static class GlobalVars {

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

	
	public static T[] AddItemToArray <T>(this T[] original, T itemToAdd, int position) {
		T[] finalArray = new T[ original.Length ];
		for(int i = 0; i < position; i ++ ) {
			finalArray[i] = original[i];
		}
		finalArray[position] = itemToAdd;
		for(int i = position; i < original.Length-1; i ++ ) {
			finalArray[i+1] = original[i];
		}
		return finalArray;
	}

	public static string[] nameArr= new string[]{
		"aaaaa",
		"bbbbb",
		"ccccc",
		"",
		"",
		"",
		"",
		"",
		"",
		""
	};
	public static int[] pointArr= new int[]{
		10000,
		5000,
		100,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1
	};
}
