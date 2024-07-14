using System;
using UnityEngine;
public class GameContext{
    public PlayerRespository playerRespository;

    public InputEntity inputEntity;

    public AssetsContext assetsContext;

    public gameEntity gameEntity;
    public GameContext(){
        playerRespository = new PlayerRespository();
        inputEntity = new InputEntity();
        gameEntity = new gameEntity();
    }

    public void Inject(AssetsContext assetsContext){
        this.assetsContext = assetsContext;
    }
}