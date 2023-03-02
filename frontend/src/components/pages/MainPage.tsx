import Markdown from "components/Markdown"
import { createSignal } from "solid-js"
import { JSX } from "solid-js/jsx-runtime"

interface ItemProps {
    children?: JSX.Element,
    active?: boolean
}

const Item = (props: ItemProps) => <div
    class="
        whitespace-nowrap
        overflow-hidden
        text-ellipsis
        cursor-pointer
        pl-6
        px-2
        py-0.5
        rounded-sm
    "
    classList={{
        "hover:bg-action-disabled/50": !props.active,
        "bg-action-disabled": props.active,
    }}>{props.children}</div>

export default function MainPage() {
    const [isResizing, setResizing] = createSignal(false)

    let sidebar: HTMLDivElement | undefined = undefined

    const handleMouseDown = (e: MouseEvent) => {
        if (e.buttons !== 1)
            return
        setResizing(true)
    }

    const handleMouseUp = () => {
        setResizing(false)
    }

    const handeMouseMove = (e: MouseEvent) => {

        if (!isResizing() || !sidebar)
            return
        const width = sidebar.clientWidth
        sidebar.style.width = width + e.movementX + "px"
    }

    return <>
        <div
            ref={sidebar}
            class="
                w-64
                px-3
                pr-0
                flex-shrink-0
                relative
                min-w-[14rem]
                max-w-[50%]
            "
            classList={{
                "cursor-w-resize select-none [&_*]:pointer-events-none": isResizing()
            }}
            onMouseMove={handeMouseMove}
            onMouseUp={handleMouseUp}
        >
            <div
                class="
                    absolute
                    top-0
                    bottom-0
                    -right-0.5
                    w-1
                    transition-colors
                    delay-0
                    hover:delay-300
                    border-l-2
                    border-dashed
                    border-action-disabled
                    hover:border-primary-disabled
                    cursor-w-resize
                "
                onMouseDown={handleMouseDown}
            ></div>
            <div
                class="
                    h-full
                    py-5 
                    space-y-1
                    overflow-y-scroll
                    overflow-x-hidden
                "
            >
                <Item>Katelynn Medhurst</Item>
                <Item active>Jasper Maglot</Item>
                <Item>Leatha Stiedemann</Item>
                <Item>Karlee Stamm</Item>
                <Item>Henri Mueller</Item>
                <Item>Luna Hoppe</Item>
                <Item>Humberto Gulgowski</Item>
                <Item>Sim Bednar</Item>
                <Item>Vincenzo Goldner</Item>
                <Item>Gerald Kreiger</Item>
                <Item>Pauline Schulist</Item>
                <Item>June Kshlerin</Item>
                <Item>Kenyon Huel</Item>
                <Item>Tianna Smith</Item>
                <Item>Antonetta Hauck</Item>
                <Item>Ashlee O'Connell</Item>
                <Item>Aiyana Hills</Item>
                <Item>Riley Will</Item>
                <Item>Orland Connelly</Item>
                <Item>Sarah Strosin</Item>
                <Item>Wilford Krajcik</Item>
                <Item>Pinkie Schmidt</Item>
                <Item>Jairo Lebsack</Item>
            </div>
        </div >
        <div
            class="bg-action-main/5 overflow-y-scroll h-full w-full"
            classList={{
                "cursor-w-resize select-none [&_*]:pointer-events-none": isResizing()
            }}
            onMouseMove={handeMouseMove}
            onMouseUp={handleMouseUp}
        >
            <div class="px-10 my-32 max-w-3xl m-auto">
                <h1 class="h1">CRISPR-Cas9</h1>
                <Markdown />
            </div>
        </div>
    </>
}