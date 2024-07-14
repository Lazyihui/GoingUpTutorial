using System;
using UnityEngine;
public class GameContext{
    public PlayerRespository playerRespository;
    public GroundRespository groundRespository;

    public InputEntity inputEntity;

    public AssetsContext assetsContext;

    public gameEntity gameEntity;
    public GameContext(){
        playerRespository = new PlayerRespository();
        groundRespository = new GroundRespository();
        inputEntity = new InputEntity();
        gameEntity = new gameEntity();
    }

    public void Inject(AssetsContext assetsContext){
        this.assetsContext = assetsContext;
    }
}