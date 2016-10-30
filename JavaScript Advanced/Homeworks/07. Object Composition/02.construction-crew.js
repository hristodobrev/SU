function constructionCrew(obj) {
    if (!obj.handsShaking) {
        return obj;
    }

    let requiredAmount = obj.weight * obj.experience * 0.1;
    obj.bloodAlcoholLevel += requiredAmount;
    obj.handsShaking = false;

    return obj;
}