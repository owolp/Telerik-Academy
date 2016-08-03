function solve() {
    return function (selector) {
        var template = "    <div id="calendar">
        {{#with data}}
        <div class="events-calendar">
            <h2 class="header">
                Appointments for <span class="month">{{month}}</span> <span class="year">{{year}}</span>
            </h2>

            {{#days}}
            <div class="col-date">
                <div class="date">{{this.day}}</div>
                <div class="events">
                    {{#this.events}}
                    <div class="event {{this.importance}}">
                        {{#if this.title}}
                        <div class="title">{{title}}</div>
                        <span class="time">at: {{time}}</span>
                        {{else}}
                            <div class="title">Free slot</div>
                        {{/if}}
                    </div>
                    {{/this.events}}
                </div>
            </div>
            {{/days}}
        {{/with}}
    </div>";
        document.getElementById(selector).innerHTML = template;
    };
}

module.exports = solve;


function solve() {
    return function (selector) {
        var template = [
        {{#with data}}
        <div class="events-calendar">
            <h2 class="header">
                Appointments for <span class="month">{{month}}</span> <span class="year">{{year}}</span>
            </h2>

            {{#days}}
            <div class="col-date">
                <div class="date">{{this.day}}</div>
                <div class="events">
                    {{#this.events}}
                    <div class="event {{this.importance}}">
                        {{#if this.title}}
                        <div class="title">{{title}}</div>
                        <span class="time">at: {{time}}</span>
                        {{else}}
                            <div class="title">Free slot</div>
                        {{/if}}
                    </div>
                    {{/this.events}}
                </div>
            </div>
            {{/days}}
        {{/with}}
        ].join('');

        if(template.length) {
            document.getElementById(selector).innerHTML = template;
        }
    };
}