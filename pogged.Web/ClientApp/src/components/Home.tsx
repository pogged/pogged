import * as React from 'react';
import { connect } from 'react-redux';

const Home = () => (
    <div>
        <h1>Hello, world!</h1>
        <p>Welcome to our new pogged Dashboard, built with:</p>
        <ul>
            <li><a href='https://get.asp.net/' target="_blank" rel="noopener noreferrer">ASP.NET Core</a> and <a href='https://dot.net/' target="_blank" rel="noopener noreferrer">.NET</a> for cross-platform server-side code</li>
            <li><a href='https://facebook.github.io/react/' target="_blank" rel="noopener noreferrer">React</a> and <a href='https://redux.js.org/' target="_blank" rel="noopener noreferrer">Redux</a> for client-side code</li>
            <li><a href='http://getbootstrap.com/' target="_blank" rel="noopener noreferrer">Bootstrap</a> and <a href="https://developer.microsoft.com/en-us/fluentui" target="_blank" rel="noopener noreferrer">Fluent UI</a> for layout and styling</li>
        </ul>
    </div>
);

fetch(`controllers/Home`);

console.log("load: Home");

export default connect()(Home);
