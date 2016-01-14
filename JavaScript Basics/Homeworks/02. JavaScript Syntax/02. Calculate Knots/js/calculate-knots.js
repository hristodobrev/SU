function updateResult() {
    var result = document.getElementById("result");
    var a = document.getElementById("a").value;

    result.value = Math.round(a * 53.99568034557235) / 100;
}