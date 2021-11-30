import React from 'react';
import ReactDOM from 'react-dom';
import Wallet from './Wallet';

it('It should mount', () => {
  const div = document.createElement('div');
  ReactDOM.render(<Wallet />, div);
  ReactDOM.unmountComponentAtNode(div);
});