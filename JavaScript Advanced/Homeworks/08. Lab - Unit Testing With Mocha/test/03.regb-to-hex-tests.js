let rgbToHexColor = require('../03.rgb-to-hex').rgbToHexColor;
let expect = require('chai').expect;

describe("rgbToHexColor(red, green, blue)", function() {
    it("should return #FF0000 for 255, 0, 0", function() {
        expect(rgbToHexColor(255, 0, 0)).to.be.equal('#FF0000');
    });
    it("should return #FF00FF for 255, 0, 255", function() {
        expect(rgbToHexColor(255, 0, 255)).to.be.equal('#FF00FF');
    });
    it("should return #00FF00 for 0, 255, 0", function() {
        expect(rgbToHexColor(0, 255, 0)).to.be.equal('#00FF00');
    });
    it("should return undefined for -100, 255, 0", function() {
        expect(rgbToHexColor(-100, 255, 0)).to.be.equal(undefined);
    });
    it("should return undefined for 100, 255, 365", function() {
        expect(rgbToHexColor(100, 255, 365)).to.be.equal(undefined);
    });
    it("should return undefined for 100, 256, 165", function() {
        expect(rgbToHexColor(100, 256, 165)).to.be.equal(undefined);
    });
});