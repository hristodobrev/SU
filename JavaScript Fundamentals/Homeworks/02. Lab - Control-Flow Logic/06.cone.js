function cone([r, h]) {
    let volume = (Math.PI * r * r * h) / 3;
    let l = Math.sqrt(h * h + r * r);
    let area = Math.PI * r * l + Math.PI * r * r;
    console.log(volume);
    console.log(area);
}