let bugtracker = (function () {
    let outputElement;
    let sortMethod = 'ID';
    let nextId = 0;
    let reports = new Map();

    function report(author, description, reproducible, severity) {
        let report = {
            id: nextId,
            author: author,
            description: description,
            reproducible: reproducible,
            severity: severity,
            status: 'Open'
        };

        reports.set(nextId, report);
        nextId++;
        reorder();
    }

    function setStatus(id, newStatus) {
        reports.get(id).status = newStatus;
        reorder();
    }

    function remove(id) {
        reports.delete(id);
        reorder();
    }

    function output(selector) {
        outputElement = $(selector);
        reorder();
    }

    function sort(method) {
        sortMethod = method;
        reorder();
    }

    function reorder() {
        let reportKeys = Array.from(reports.keys());
        if (sortMethod.toUpperCase() == 'ID') {
            reportKeys.sort((a, b) => {
                return Number(a) - Number(b);
            });
        } else if (sortMethod.toLowerCase() == 'severity') {
            reportKeys.sort((a, b) => {
                return Number(reports.get(a).severity) - Number(reports.get(b).severity);
            });
        } else if (sortMethod.toLowerCase() == 'author') {
            reportKeys.sort((a, b) => {
                return reports.get(a).author > reports.get(b).author;
            });
        }

        outputElement.html('');
        for (let key of reportKeys) {
            let report = reports.get(key);

            let reportDiv = $('<div id="report_' + report.id + '" class="report"></div>');
            let body = $('<div class="body"></div>');
            body.append($('<p>').text(report.description));
            let title = $('<div class="title"></div>');
            title.append($('<span class="author">').text(report.author));
            title.append($('<span class="status">').text(report.status + ' | ' + report.severity));
            reportDiv.append(body).append(title);
            outputElement.append(reportDiv);
        }
    }

    return {
        report: report,
        sort: sort,
        setStatus: setStatus,
        remove: remove,
        output: output
    };
})();