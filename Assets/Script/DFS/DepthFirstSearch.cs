using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 情報を読み込む
/// </summary>
public class DepthFirstSearch : MonoBehaviour
{
    [SerializeField] Data _data;

    private List<string> routeList = new List<string>();

    private void Start()
    {
        string[] lines = _data.DFSData.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        var prms = Array.ConvertAll(lines[0].Split(), int.Parse); //情報の読み取り
        int vertexQuantity = prms[0], start = prms[1], goal = prms[2], rowCount = prms[3];
        var adj = new bool[vertexQuantity, vertexQuantity];//隣接情報を入れるための配列
        var visitedNodes = new bool[vertexQuantity];//訪問済み頂点
    
        for (int i = 0; i < rowCount; i++)
        {
            var edges = Array.ConvertAll(lines[i + 1].Split(), int.Parse);
            adj[edges[0], edges[1]] = true;
            adj[edges[1], edges[0]] = true;
        }//隣接情報を読み込む

        var route = new Stack<int>();//現在進行中のルートを記憶
        route.Push(start);//スタート地点を入れる
        visitedNodes[start] = true;//スタート地点は訪問済みにする
        DFS(route, adj, visitedNodes, vertexQuantity, goal, routeList);//探索開始

        foreach (var r in routeList)
        {
            Debug.Log(r);
        }
    }

    /// <summary>
    /// 深さ優先探索の処理
    /// </summary>
    /// <param name="route"></param>
    /// <param name="adj"></param>
    /// <param name="visitedNodes"></param>
    /// <param name="vertexQuantity"></param>
    /// <param name="goal"></param>
    static void DFS(Stack<int> route, bool[,] adj, bool[] visitedNodes, int vertexQuantity, int goal, List<string> routeList)
    {
        var currentNode = route.Pop();
        route.Push(currentNode);

        for (int i = 0; i < vertexQuantity; i++)
        {
            var nextNode = i;//移動先頂点候補

            if (!visitedNodes[nextNode] && adj[currentNode, nextNode])
            {
                route.Push(nextNode);
                //ゴールじゃなかった時、再帰呼び出しでnextNodesをcurrentNodeにしたループが発生
                //この時、そのノードが未訪問にしてあるとif文に入ってしまう
                visitedNodes[nextNode] = true;

                if (nextNode == goal)
                {
                    routeList.Add(string.Join("->", route.Reverse()));
                }
                else
                {
                    DFS(route, adj, visitedNodes, vertexQuantity, goal, routeList);
                }
                visitedNodes[route.Pop()] = false;//今回0と隣接したノードの探索が終了→for文がまわり、また隣接しているか確かめる
            }
        }
    }
}
