import { FC, ReactNode } from "react";

type NavbarArgs = {
    children: ReactNode[];
}

const SDNavbar: FC<NavbarArgs> = (props) => {
    return (<>
        <div style={{ display: 'flex', flexDirection: 'row-reverse', gap: '10px' }}>
            <>{props.children}</>
        </div>
    </>);
}

export default SDNavbar;