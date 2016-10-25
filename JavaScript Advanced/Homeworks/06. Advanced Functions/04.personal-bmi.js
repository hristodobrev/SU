function personalBMI(name, age, weight, height) {
    let personalInfo = {age, weight, height};
    let BMI = Math.round(weight / ((height / 100) * (height / 100)));
    let status;
    if (BMI < 18.5) {
        status = 'underweight';
    } else if (BMI < 25) {
        status = 'normal';
    } else if (BMI < 30) {
        status = 'overweight';
    } else {
        status = 'obese';
    }

    let person = {name, personalInfo, BMI, status};
    if (status === 'obese') {
        person['recommendation'] = 'admission required';
    }

    return person;
}

console.log(personalBMI('Peter', 29, 175, 182));