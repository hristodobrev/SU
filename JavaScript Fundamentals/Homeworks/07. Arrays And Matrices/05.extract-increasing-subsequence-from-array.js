function extractNonDecreasingSequence(nums) {
    nums = nums.map(Number);
    let previous = nums[0];
    nums = nums.filter((a) => {
        let isBigger = a >= previous;
        previous = a;
        return isBigger;
    });

    return nums.join('\n');
}