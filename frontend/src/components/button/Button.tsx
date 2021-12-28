import { FC, ReactNode } from "react";

require('./Button.css');

type ButtonStyle = 'alert' | 'accent' | 'primary';

type SDButtonArgs = {
    onClick: () => void;
    style?: ButtonStyle;
    children: ReactNode;
}

const SDButton: FC<SDButtonArgs> = (props) => {
    return (
        <button className="SDButton SDButton--primary SDButton__text SDButton__text--primary" onClick={props.onClick}>
            {props.children}
        </button>
    );
}

SDButton.defaultProps = {
    style: 'primary',
}

export default SDButton;