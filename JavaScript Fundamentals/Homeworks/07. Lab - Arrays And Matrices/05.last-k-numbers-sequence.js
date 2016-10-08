function lastKNumbersSequence([n, k]) {
    let nums = [1];
    for (let i = 1; i < n; i++) {
        let lastNums = nums.slice(Math.max(0, nums.length - k));
        nums[i] = lastNums.reduce((a, b) => a + b);
    }

    return nums.join(' ');
}