import { FunctionComponent, ReactNode } from "react";

interface GameContainerProps {
    game: ReactNode;
    sidebar: ReactNode;
    actions: ReactNode;
}

// 200px 70% 700%
const GameContainer: FunctionComponent<GameContainerProps> = (props) => {
    return (
        <div style={{position: 'relative'}}>
            <div style={{position: 'absolute'}}>
                <div style={{position: 'relative'}}>
                    <div style={{position: 'absolute', top: 10, left: -10, width: '100%', height: 50, zIndex: 1}}>
                        <div style={{display: 'flex', flexDirection: 'row-reverse'}}>
                            <>{props.actions}</>
                        </div>
                    </div>
                    <div style={{position: 'absolute', zIndex: 0}}>
                        {props.game}
                    </div>
                </div>
            </div>
            <div style={{ width: '100vw', height: '100vh', display: 'flex', flexDirection: 'row', position: 'absolute'}}>
                <div style={{ width: '70%' }}></div>
                {props.sidebar}
            </div>
        </div>
    );
}

export default GameContainer;