function solve() {
    return function (selector) {
        var template = [
'<div class="events-calendar">' +
'<h2 class="header">' +
'Appointments for <span class="month">{{month}}</span> <span class="year">{{year}}</span>' +
'</h2>' +
'{{#days}}' +
'<div class="col-date">' +
'<div class="date">{{day}}</div>' +
'<div class="events">' +
'{{#events}}' +
'<div class="event {{importance}}" {{#if title}}title="{{{comment}}}"{{/if}}>' +
'{{#if title}}' +
'<div class="title">{{title}}</div>' +
'<span class="time">at: {{time}}</span>' +
'{{else}}' +
'<div class="title">Free slot</div>' +
'{{/if}}' +
'</div>' +
'{{/events}}' +
'</div>' +
'</div>' +
'{{/days}}' +
'</div>'
        ].join('');

        if(template.length) {
            document.getElementById(selector).innerHTML = template;
        }
    };
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}