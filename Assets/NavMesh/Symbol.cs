using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol : StaticSymbol
{
    protected override void Start() {
        base.Start();
        StartCoroutine(SwitchSymbol());
    }

    IEnumerator SwitchSymbol() {
        while (true) {
            yield return new WaitForSeconds(1);
            CurrentSymbol = GenerateRandomSymbol();
        }
    }

}

public enum SymbolEnum
{
    Rock, Paper, Scissors
}