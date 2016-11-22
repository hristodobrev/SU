function validateRequest(request) {
    let validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    if (!request.method || !validMethods.includes(request.method)) {
        throw new Error('Invalid request header: Invalid Method');
    }

    let uriReg = /^\*$|^[0-9A-Za-z\.]+$/;
    if (!request.uri || !uriReg.test(request.uri)) {
        throw new Error('Invalid request header: Invalid URI');
    }

    let validVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    if (!request.version || !validVersions.includes(request.version)) {
        throw new Error('Invalid request header: Invalid Version');
    }

    let msgReg = /^[^\<\>\\\&\'\"]*$/;
    if (request.message == undefined || !msgReg.test(request.message)) {
        throw new Error('Invalid request header: Invalid Message');
    }

    return request;
}

validateRequest({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: 'Some valid message.'
});