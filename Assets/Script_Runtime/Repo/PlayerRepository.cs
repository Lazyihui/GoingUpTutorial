using System;
using System.Collections.Generic;


public class PlayerRespository {

    Dictionary<int, PlayerEntity> all;

    PlayerEntity[] temArray;

    public PlayerRespository() {
        all = new Dictionary<int, PlayerEntity>();
        temArray = new PlayerEntity[5];
    }

    public void Add(PlayerEntity entity) {
        all.Add(entity.id, entity);
    }

    public void Remove(PlayerEntity entity) {
        all.Remove(entity.id);
    }

    public int TakeAll(out PlayerEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new PlayerEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }

    public bool TryGet(int id, out PlayerEntity entity) {
        return all.TryGetValue(id, out entity);
    }

    public void Foreach(Action<PlayerEntity> action) {
        foreach (var item in all.Values) {
            action(item);
        }
    }
    public PlayerEntity Find(Predicate<PlayerEntity> predicate) {
        foreach (PlayerEntity Player in all.Values) {
            bool isMatch = predicate(Player);

            if (isMatch) {
                return Player;
            }
        }
        return null;
    }

}