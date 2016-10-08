function distOverTime([v1, v2, time]) {
    let dist1 = ((Number(v1) * 1000) / 3600) * time;
    let dist2 = ((Number(v2) * 1000) / 3600) * time;

    let alphaDist = Math.abs(dist1 - dist2);
    return alphaDist;
}