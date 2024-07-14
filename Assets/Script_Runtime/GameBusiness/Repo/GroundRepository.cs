using System;
using System.Collections.Generic;


public class GroundRespository {

    Dictionary<int, GroundEntity> all;

    GroundEntity[] temArray;

    public GroundRespository() {
        all = new Dictionary<int, GroundEntity>();
        temArray = new GroundEntity[5];
    }

    public void Add(GroundEntity entity) {
        all.Add(entity.id, entity);
    }

    public void Remove(GroundEntity entity) {
        all.Remove(entity.id);
    }

    public int TakeAll(out GroundEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new GroundEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }

    public bool TryGet(int id, out GroundEntity entity) {
        return all.TryGetValue(id, out entity);
    }

    public void Foreach(Action<GroundEntity> action) {
        foreach (var item in all.Values) {
            action(item);
        }
    }
    public GroundEntity Find(Predicate<GroundEntity> predicate) {
        foreach (GroundEntity Ground in all.Values) {
            bool isMatch = predicate(Ground);

            if (isMatch) {
                return Ground;
            }
        }
        return null;
    }

}