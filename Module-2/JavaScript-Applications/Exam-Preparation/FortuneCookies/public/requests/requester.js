const requester = (() => {

    let pathUrl = 'http://localhost:4000';

    function get(url, headers = {}) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: pathUrl + url,
                method: 'GET',
                headers: headers,
                contentType: 'application/json'
            })
                .done(resolve)
                .fail(reject);
        });
    }

    function putJSON(url, json, headers = {}) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: pathUrl + url,
                method: 'PUT',
                headers: headers,
                contentType: 'application/json',
                data: JSON.stringify(json)
            })
                .done(resolve)
                .fail(reject);
        });
    }

    function postJSON(url, json, headers = {}) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: pathUrl + url,
                method: 'POST',
                headers: headers,
                contentType: 'application/json',
                data: JSON.stringify(json)
            })
                .done(resolve)
                .fail(reject);
        });
    }

    return {
        get,
        postJSON,
        putJSON
    };
})();