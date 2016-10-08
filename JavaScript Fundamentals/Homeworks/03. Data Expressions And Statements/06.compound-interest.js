function compoundInterest([sum, interestRate, compoundPeriod, period]) {
    let result = sum * Math.pow((1 + (interestRate / 100) / (12 / compoundPeriod)),
            (12 / compoundPeriod) * period);

    return result;
}