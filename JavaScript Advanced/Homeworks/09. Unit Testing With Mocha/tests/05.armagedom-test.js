let expect = require('chai').expect;
let jsdom = require('jsdom-global')();
let $ = require('jquery');

function nuke(selector1, selector2) {
    if (selector1 === selector2) return;
    $(selector1).filter(selector2).remove();
}

describe('nuke', function () {
    let html;
    beforeEach(function () {
        html = $('body').html();
    });

    it('should do nothing if the selectors are the same',function () {
        nuke('.target','.target');
        expect($('body').html()).to.be.equal(html)
    });

    it('should do nothing if the second selector is omitted',function () {
        nuke('.target');
        expect($('body').html()).to.be.equal(html)
    });

    it('should do nothing if one of the selectors is invalid',function () {
        nuke(5,'.target');
        expect($('body').html()).to.be.equal(html)
    });

    it('should do nothing if the first selector is empty',function () {
        nuke('','.target');
        expect($('body').html()).to.be.equal(html)
    });

    it('should do nothing if the second selector is empty',function () {
        nuke('.target','');
        expect($('body').html()).to.be.equal(html)
    });

    it('should delete all nodes that match .target and .nested',function () {
        nuke('.target','.nested');
        expect($('.target').filter('.nested').length).to.be.equal(0);
    });

    it('should delete all nodes that match .target and span',function () {
        nuke('.target','span');
        expect($('.target').filter('span').length).to.be.equal(0);
    });

    it('should delete all nodes that match * :not(:has(*)) and span',function () {
        nuke('* :not(:has(*))','span');
        expect($('* :not(:has(*))').filter('span').length).to.be.equal(0);
    });

    it('should delete all nodes that match * :has(p) and div',function () {
        nuke('* :has(p)','div');
        expect($('* :has(p)').filter('div').length).to.be.equal(0);
    });

    it('should remove the first matched element if one of the selectors is an id',function () {
        let firstMatchedElement=$('div').filter('#target');
        nuke('#target','div');
        expect($('div').filter('#target').length).not.equal(firstMatchedElement)
    });
});