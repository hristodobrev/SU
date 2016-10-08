function figureArea([w, h, W, H]) {
    var [s1, s2, s3] = [w * h, W * H, Math.min(w, W) * Math.min(h, H)];
    var area = s1 + s2 - s3;
    console.log(area);
}