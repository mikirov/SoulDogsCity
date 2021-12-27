import { FunctionComponent, ReactNode } from "react";

interface GameContainerProps {
    game: ReactNode;
    sidebar: ReactNode;
}

// 200px 70% 700%
const GameContainer: FunctionComponent<GameContainerProps> = (props) => {
    return (
        <div style={{position: 'relative'}}>
            <div style={{position: 'absolute'}}>{props.game}</div>
            <div style={{ width: '100vw', height: '100vh', display: 'flex', flexDirection: 'row', position: 'absolute'}}>
                <div style={{ width: '70%' }}></div>
                {props.sidebar}
            </div>
        </div>
    );
}

export default GameContainer;