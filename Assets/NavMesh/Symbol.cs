using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol : MonoBehaviour
{
    private SymbolEnum? symbol;

    public SymbolEnum CurrentSymbol
    {
        get { return symbol.HasValue ?  symbol.Value : SymbolEnum.Kamen; }
        private set { 
            symbol = value;
            quadRenderer.material = materials[(int)symbol.Value];
        }
    }


    [SerializeField]
    private MeshRenderer quadRenderer;

    [SerializeField]
    private Material[] materials;

    void Start()
    {
        CurrentSymbol = GenerateRandomSmbol();
        StartCoroutine(SwitchSymbol());     
    }

    IEnumerator SwitchSymbol() { 
    while (true)
        {
            yield return new WaitForSeconds(5);
            CurrentSymbol = GenerateRandomSmbol();
        }
    }

    private SymbolEnum GenerateRandomSmbol()
    {
        SymbolEnum newSymbol;
        do {
            newSymbol = (SymbolEnum)UnityEngine.Random.Range(0, 3);
        }
        while (newSymbol == CurrentSymbol);

        return newSymbol;

    }
}

public enum SymbolEnum
{
    Kamen, Nuzky, Papir
}
