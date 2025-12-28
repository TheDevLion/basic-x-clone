import RepeatIcon from '@mui/icons-material/Repeat';
import { BasicXCloneCardContainer, BasicXCloneCardHeader, BasicXCloneText, RepostIconContainer } from './styles';
import { formatDate, getLoggedUser } from '../../helpers/helper';
import { BasicXCloneRecord } from '../../models/Record';

interface BasicXCloneCardProps {
    record: BasicXCloneRecord;
    setIsDialogOpen: React.Dispatch<React.SetStateAction<boolean>>;
    setSelectedIdToRepost: React.Dispatch<React.SetStateAction<number>>;
}

export const BasicXCloneCard = ({record, setIsDialogOpen, setSelectedIdToRepost}: BasicXCloneCardProps) => {
    /*====================== RENDER ======================*/
    return <BasicXCloneCardContainer>
        <BasicXCloneCardHeader>
            <span>Author: {record.creator}</span>
            <span>{formatDate(record.creationDate)}</span>
        </BasicXCloneCardHeader>
        <BasicXCloneText>
            {record.text}
        </BasicXCloneText>
        {record.isPost && record.creator !== getLoggedUser() && <RepostIconContainer>
                <RepeatIcon onClick={() => {
                    setIsDialogOpen(true);
                    setSelectedIdToRepost(record.id);
                }}/>
        </RepostIconContainer>}
    </BasicXCloneCardContainer>
}
