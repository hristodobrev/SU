function imperialUnits([inches]) {
    let remainingInches = inches % 12;
    let feet = (inches - remainingInches) / 12;

    return `${feet}'-${remainingInches}"`;
}