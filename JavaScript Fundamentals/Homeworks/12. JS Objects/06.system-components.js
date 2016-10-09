function systemComponents(dataRows) {
    let system = new Map();
    for (let dataRow of dataRows) {
        let [systemName, componentName, subcomponentName] = dataRow.split(' | ');
        if (!system.has(systemName)) {
            system.set(systemName, new Map());
        }
        if (!system.get(systemName).has(componentName)) {
            system.get(systemName).set(componentName, []);
        }
        system.get(systemName).get(componentName).push(subcomponentName);
    }

    let systemNames = Array.from(system.keys()).sort((a, b) => {
        if (Array.from(system.get(a).keys()).length < Array.from(system.get(b).keys()).length) return 1;
        if (Array.from(system.get(a).keys()).length > Array.from(system.get(b).keys()).length) return -1;
        if (a > b) return 1;
        if (a < b) return -1;
    });
    for (let systemName of systemNames) {
        console.log(systemName);
        let componentNames = Array.from(system.get(systemName).keys()).sort((a, b) => {
            if (Array.from(system.get(systemName).get(a).keys()).length < Array.from(system.get(systemName).get(b).keys()).length) return 1;
            if (Array.from(system.get(systemName).get(a).keys()).length > Array.from(system.get(systemName).get(b).keys()).length) return -1;
        });
        for (let componentName of componentNames) {
            console.log(`|||${componentName}`);
            let subcomponents = system.get(systemName).get(componentName);
            for (let subcomponent of subcomponents) {
                console.log(`||||||${subcomponent}`);
            }
        }
    }
}

systemComponents([
    'SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    // 'Alpha | CoreA | A23',
    // 'Alpha | Digital Site | Login Page',
    // 'Alpha | CoreB | B24',
    // 'Alpha | CoreA | A24',
    // 'Alpha | CoreA | A25',
    // 'Alpha | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security'
]);