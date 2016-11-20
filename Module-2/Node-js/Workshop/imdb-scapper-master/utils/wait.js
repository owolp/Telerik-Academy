/* globals module Promise setTimeout*/

"use strict";

function wait(time) {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve();
        }, time);
    });
}

module.exports.wait = wait;