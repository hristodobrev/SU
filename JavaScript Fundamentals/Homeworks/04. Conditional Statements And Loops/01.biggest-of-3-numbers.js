function biggestOf3Nums(nums) {
    let max = -Number.MAX_VALUE;
    for (let i = 0; i < nums.length; i++) {
        if (max < Number(nums[i])) {
            max = Number(nums[i]);
        }
    }

    return max;
}