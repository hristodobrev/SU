function domTraversal(selector) {
    let element = $(selector);
    let elementsMap = new Map();
    let currentLevel = 0;

    traverseElement(element);

    function traverseElement(el) {
        currentLevel++;
        let children = el.children();
        for (let i = 0; i < children.length; i++) {
            let currentChild = $(children[i]);
            elementsMap.set(currentChild, currentLevel);
            traverseElement(currentChild);
            currentLevel--;
        }
    }

    //console.log(elementsMap);
    let deepestElement;
    for (let [el, count] of elementsMap) {
        if (!deepestElement) {
            deepestElement = el;
        } else if (elementsMap.get(deepestElement) <= elementsMap.get(el)) {
            deepestElement = el;
        }
    }
    //console.log(deepestElement);
    deepestElement.addClass('highlight');

    while (deepestElement.get(0) != element.get(0)) {
        deepestElement = deepestElement.parent();
        deepestElement.addClass('highlight');
    }
}